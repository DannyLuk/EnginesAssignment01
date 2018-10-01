using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Command
{
    public class InputManager : MonoBehaviour
    {
        //
        public static List<Command> commandHistory = new List<Command>();
        public static Command[] commandListDEFAUT = new Command[300];       // 300 should probably be enough to cover all keycodes. how many could there possibly be?
        public static Command[] commandListUSER = new Command[300];

        private bool remappingKeys = false;
        private string remappingWhat = "Nothing";

        public Text buttonRemapForward;
        public Text buttonRemapBackward;
        public Text buttonRemapLeft;
        public Text buttonRemapRight;

        private int currentMappingForward;
        private int currentMappingBackward;
        private int currentMappingLeft;
        private int currentMappingRight;

        // Use this for initialization
        void Start()
        {
            // Unmapped Everything
            for (int i = 0; i < commandListDEFAUT.Length; i++)
            {
                commandListDEFAUT[i] = new Unmapped();
            }
            // Set Default Mappings
            commandListDEFAUT[KeyCode.W.GetHashCode()] = new MoveForward();
            commandListDEFAUT[KeyCode.A.GetHashCode()] = new MoveLeft();
            commandListDEFAUT[KeyCode.S.GetHashCode()] = new MoveBackward();
            commandListDEFAUT[KeyCode.D.GetHashCode()] = new MoveRight();
            commandListDEFAUT[KeyCode.Z.GetHashCode()] = new UndoLast();
            //
            currentMappingForward = KeyCode.W.GetHashCode();
            currentMappingBackward = KeyCode.S.GetHashCode();
            currentMappingLeft = KeyCode.A.GetHashCode();
            currentMappingRight = KeyCode.D.GetHashCode();
            // 
            commandListUSER = commandListDEFAUT;
        }

        // Update is called once per frame
        void Update()
        {
            // Do the thing
        }

        //
        private void OnGUI()
        {
            Event e = Event.current;
            if (e.isKey)
            {
                if (Input.GetKeyDown(e.keyCode) && !remappingKeys)
                {
                    commandListUSER[e.keyCode.GetHashCode()].Execute(this.gameObject, commandListUSER[e.keyCode.GetHashCode()]);
                }

                // Cancel the Remapping
                if (remappingKeys && (e.keyCode == KeyCode.Escape))
                {
                    remappingWhat = "Nothing";
                    remappingKeys = false;
                }
                //
                if (remappingKeys && remappingWhat == "Forward" && (e.keyCode != KeyCode.Escape))
                {
                    // Clear old mapping
                    commandListUSER[currentMappingForward] = new Unmapped();
                    // Map new
                    commandListUSER[e.keyCode.GetHashCode()] = new MoveForward();
                    currentMappingForward = e.keyCode.GetHashCode();
                    remappingWhat = "Nothing";
                    remappingKeys = false;
                    buttonRemapForward.text = "Click to Remap";
                }
                if (remappingKeys && remappingWhat == "Backward" && (e.keyCode != KeyCode.Escape))
                {
                    // Clear old mapping
                    commandListUSER[currentMappingBackward] = new Unmapped();
                    // Map new
                    commandListUSER[e.keyCode.GetHashCode()] = new MoveBackward();
                    remappingWhat = "Nothing";
                    remappingKeys = false;
                    buttonRemapBackward.text = "Click to Remap";
                }
                if (remappingKeys && remappingWhat == "Left" && (e.keyCode != KeyCode.Escape))
                {
                    // Clear old mapping
                    commandListUSER[currentMappingLeft] = new Unmapped();
                    // Map new
                    commandListUSER[e.keyCode.GetHashCode()] = new MoveLeft();
                    remappingWhat = "Nothing";
                    remappingKeys = false;
                    buttonRemapLeft.text = "Click to Remap";
                }
                if (remappingKeys && remappingWhat == "Right" && (e.keyCode != KeyCode.Escape))
                {
                    // Clear old mapping
                    commandListUSER[currentMappingRight] = new Unmapped();
                    // Map new
                    commandListUSER[e.keyCode.GetHashCode()] = new MoveRight();
                    remappingWhat = "Nothing";
                    remappingKeys = false;
                    buttonRemapRight.text = "Click to Remap";
                }
            }
        }

        //
        public void RemapForward()
        {
            remappingKeys = true;
            remappingWhat = "Forward";
            buttonRemapForward.text = "Press Any Key";
        }
        //
        public void RemapBackward()
        {
            remappingKeys = true;
            remappingWhat = "Backward";
            buttonRemapBackward.text = "Press Any Key";
        }
        //
        public void RemapLeft()
        {
            remappingKeys = true;
            remappingWhat = "Left";
            buttonRemapLeft.text = "Press Any Key";
        }
        //
        public void RemapRight()
        {
            remappingKeys = true;
            remappingWhat = "Right";
            buttonRemapRight.text = "Press Any Key";
        }
    }

    //
    public abstract class Command : MonoBehaviour
    {
        public abstract void Execute(GameObject a_gameObject, Command a_command);

        public abstract void Undo(GameObject a_gameObject);
    }

    //
    public class Unmapped : Command
    {
        public override void Execute(GameObject self, Command a_command)
        {
            //
        }

        public override void Undo(GameObject self)
        {
            //
        }
    }

    //
    public class MoveForward : Command
    {
        public override void Execute(GameObject self, Command a_command)
        {
            //Debug.Log("I moving forwards");
            self.transform.Translate(0, 0, 1);

            InputManager.commandHistory.Add(a_command);
        }

        public override void Undo(GameObject self)
        {
            //Debug.Log("I moving unForwards");
            self.transform.Translate(0, 0, -1);
        }
    }

    //
    public class MoveBackward : Command
    {
        public override void Execute(GameObject self, Command a_command)
        {
            //
            self.transform.Translate(0, 0, -1);

            InputManager.commandHistory.Add(a_command);
        }

        public override void Undo(GameObject self)
        {
            //
            self.transform.Translate(0, 0, 1);
        }
    }

    //
    public class MoveRight : Command
    {
        public override void Execute(GameObject self, Command a_command)
        {
            //
            self.transform.Translate(1, 0, 0);

            InputManager.commandHistory.Add(a_command);
        }

        public override void Undo(GameObject self)
        {
            //
            self.transform.Translate(-1, 0, 0);
        }
    }

    //
    public class MoveLeft : Command
    {
        public override void Execute(GameObject self, Command a_command)
        {
            //
            self.transform.Translate(-1, 0, 0);

            InputManager.commandHistory.Add(a_command);
        }

        public override void Undo(GameObject self)
        {
            //
            self.transform.Translate(1, 0, 0);
        }
    }

    //
    public class UndoLast : Command
    {
        public override void Execute(GameObject self, Command a_command)
        {
            //
            //Debug.Log("Undoing last command");
            List<Command> commandHistory = InputManager.commandHistory;

            if (commandHistory.Count > 0)
            {
                // 
                Command latestCommand = commandHistory[commandHistory.Count - 1];
                //
                latestCommand.Undo(self);
                //
                commandHistory.RemoveAt(commandHistory.Count - 1);
            }
        }

        public override void Undo(GameObject self)
        {
            //
        }
    }

}
