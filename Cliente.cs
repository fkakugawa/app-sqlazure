namespace app_sqlazure
{
    public class Cliente
    {
        public Cliente()
        {
            this.Nome = "";
            this.Email = "";
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}