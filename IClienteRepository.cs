namespace app_sqlazure
{
    public interface IClienteRepository
    {
         int Add(Cliente cliente);
         IEnumerable<Cliente> GetAll();
    }
}