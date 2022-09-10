namespace DonatAbstract
{
    public class Manager
    {
        Input input;
        public Manager(Type input, Type math, Type output)
        {
            this.input = input.GetConstructors()[0].Invoke(new object[] { () => F() }) as Input;
        }

        void F()
        {

        }
    }
}
