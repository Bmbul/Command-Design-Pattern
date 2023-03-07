using System.Collections.Generic;
using UnityEngine;

namespace Command_Pattern
{
    public class InputHandler : MonoBehaviour
    {
        Transform boxTransform;
        public Stack<int> commandsStack = new Stack<int>();
        public Stack<int> backup = new Stack<int>();
        Commands commands;

        private void Start()
        {
            boxTransform = transform;
            commands = new Commands();
        }

        void Update()
        {
            ReadInput();
        }

        void ReadInput()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                ExecuteNewCommand(commands.commands[(int)CommandIndex.forward]);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                ExecuteNewCommand(commands.commands[(int)CommandIndex.left]);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                ExecuteNewCommand(commands.commands[(int)CommandIndex.backward]);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                ExecuteNewCommand(commands.commands[(int)CommandIndex.right]);
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                UndoCommand();
            }
            else if(Input.GetKeyDown(KeyCode.F))
            {
                RedoCommand();
            }
        }

        void ExecuteNewCommand(Command command)
        {
            commandsStack.Push(command(boxTransform));
            backup.Clear(); 
        }

        void UndoCommand()
        {
            if (commandsStack.Count < 1)
                return ;
            int commandIndex = commandsStack.Pop();
            backup.Push(commandIndex);
            commandIndex = (commandIndex % 2 == 1) ? commandIndex - 1 : commandIndex + 1;
            commands.commands[commandIndex](boxTransform);
        }

        void RedoCommand()
        {
            if (backup.Count < 1)
                return ;
            int commandIndex = backup.Pop();
            commands.commands[commandIndex](boxTransform);
            commandsStack.Push(commandIndex);
        }
    }
}