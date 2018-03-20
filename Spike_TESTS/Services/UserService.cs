using Spike_TESTS.App_Data;
using Spike_TESTS.Models;
using System.Collections.Generic;
using System.Linq;

namespace Spike_TESTS.Services
{
    public class UserService : IUserService
    {
       
        public List<User> ListUsers()
        {
            return Data.Users
                .OrderBy(o => o.FirstName)
                .Where(u => u.Status == UserStatus.Active)
                .ToList();
            //return SortedList;
            //return Data.Users.ToList();
        }
        
        
        
    }

    public interface IUserService
    {

    }
}

public class MYparent
{
    public string _value2;
}

public static class Extentions
{
    public static string AddNumberEnd(this string strin, int value)
    {
        return strin + value.ToString();
    }

    public static string AddHelloAtTheEnd(this string strin)
    {
        return strin + "hello";
    }

}

public class MycClass : MYparent
{
    int _classVar;

    public void main()
    {
        //var result = AddNumberToString("aaa", 123);
        var result = "asdasd".AddNumberEnd(123).AddHelloAtTheEnd();

        //console.write(result);
    }

    public string AddNumberToString(string strin, int value)
    {
        return strin + value.ToString();
    }

    private string MyOtherMethd(int something)
    {
        _classVar = something;
        
        return something.ToString();
    }
}