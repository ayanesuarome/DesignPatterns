namespace CommandPattern
{
    internal interface ICommand
    {
        void Call();
        void Undo();
        bool Success { get; set; }
    }
}
