namespace E_CommerceProduct.Application.Exceptions
{
    public class AlreadyExistsException(string message) : Exception(message)
    {
        public string Messige = "This Item Already Exist";
    }
}
