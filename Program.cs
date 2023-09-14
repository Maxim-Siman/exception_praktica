class Program
{
    public string password;
    public string confirmpassword;
    public string login;

    public Program(string password, string confirmpassword, string login)
    {
        this.password = password;
        this.confirmpassword = confirmpassword;
        this.login = login;
    }

    static void Main(string[] args)
    {
        try
        {
            Program user1 = new Program("asdasd_123", "asdasd_123", "User1_2");
            user1.Validate();
            Program user2 = new Program("asdasd_123", "asdasd", "User1_2");
            user2.Validate();
            Program user3 = new Program("asdasd_12333333333333333333333333333333333333333", "asdasd_12333333333333333333333333333333333333333", "User1_222222222222222222222222222222222");
            user3.Validate();
            Program user4 = new Program("asdasd_123", "asdasd_123", "User1_2!@$");
            user4.Validate();
        }
        catch (Anotherpassword ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Wrongpassword ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Longpassword ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Longlogin ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadLine();
    }

    public void Validate()
    {
        if (password != confirmpassword)
        {
            throw new Anotherpassword("Пароли не совпадают");
        }

        if (password.Length > 20)
        {
            throw new Longpassword("Пароль слишком длинный");
        }
        if (login.Length > 20)
        {
            throw new Longlogin("Логин слишком длинный");
        }

        char[] loginarr = login.ToCharArray();
        foreach (char ch in loginarr)
        {
            if (!char.IsLetterOrDigit(ch) && ch != '_')
            {
                throw new Wrongpassword("Имя пользователя содержит недопустимые символы");
            }
        }
    }



    public class Anotherpassword : ApplicationException
    {
        public Anotherpassword() { }
        public Anotherpassword(string message) : base(message) { }
        public Anotherpassword(string message, Exception ex) : base(message) { }
    }

    public class Longpassword : ApplicationException
    {
        public Longpassword() { }
        public Longpassword(string message) : base(message) { }
        public Longpassword(string message, Exception ex) : base(message) { }
    }

    public class Wrongpassword : ApplicationException
    {
        public Wrongpassword() { }
        public Wrongpassword(string message) : base(message) { }
        public Wrongpassword(string message, Exception ex) : base(message) { }
    }
    public class Longlogin : ApplicationException
    {
        public Longlogin() { }
        public Longlogin(string message) : base(message) { }
        public Longlogin(string message, Exception ex) : base(message) { }
    }
}