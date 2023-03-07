using UnityEngine;

namespace Command_Pattern
{
    public enum CommandIndex {forward, backward, right, left}
    public delegate int Command(Transform actor);

    public class Commands
    {
        static int moveDistance = 1;

        public Command[] commands = new Command[4];


        public Commands()
        {
            commands[(int)CommandIndex.forward] = MoveForwardFunction;
            commands[(int)CommandIndex.backward] = MoveBackwardFunction;
            commands[(int)CommandIndex.right] = MoveRightFunction;
            commands[(int)CommandIndex.left] = MoveLeftFunction;
        }

        static int MoveForwardFunction(Transform actor)
        {
            actor.Translate(Vector3.forward * moveDistance);
            return (int)CommandIndex.forward;
        }

        static int MoveBackwardFunction(Transform actor)
        {
            actor.Translate(Vector3.back * moveDistance);
            return (int)CommandIndex.backward;
        }

        static int MoveRightFunction(Transform actor)
        {
            actor.Translate(Vector3.right * moveDistance);
            return (int)CommandIndex.right;
        }

        static int MoveLeftFunction(Transform actor)
        {
            actor.Translate(Vector3.left * moveDistance);
            return (int)CommandIndex.left;
        }
    }
}