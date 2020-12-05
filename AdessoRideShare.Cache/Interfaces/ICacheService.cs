using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cache.Services
{
  public interface ICacheService
  {

    Task<string> GetValue(string key);

    Task RemoveValue(string key);

    Task SetValue(string key, object myObject);

    Task SetValue<T>(string key, T myObject);

    Task SetValue<T>(string key, T myObject, int second);

    Task<T> GetValue<T>(string key);
  }
}
