using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.Extensions.Options;

namespace BusinessLayer
{
    public class DataFactory : IDataFactory
    {
        private readonly DataSettings _type;

        public DataFactory(IOptions<DataSettings> options)
        {
            _type = options.Value;
        }

        public IDataService GetService()
        {
            switch (_type.DataType)
            {
                case "JSON":
                    return new JSONService();
                    break;
                case "SQL":
                    return new SQLService();
                    break;
                default:
                    return new SQLService();
                    break;
            }
        }

            
    }
}
