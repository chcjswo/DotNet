using IBatisNet.DataMapper;
using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper.Configuration;
using System.Configuration;
using IBatisNet.Common;

namespace DolPic.Data.DataMappers.Service
{
    public class DolPicServiceDataMapper
    {
        private static volatile ISqlMapper _mapper = null;

        protected static void Configure(object obj)
        {
            _mapper = null;
        }

        protected static void InitMapper()
        {
            DomSqlMapBuilder builder = new DomSqlMapBuilder();

            _mapper = builder.Configure(Resources.GetEmbeddedResourceAsXmlDocument("Configs.DolPic.Service.SqlMap.config, DolPic.Data"));

            _mapper.DataSource = new DataSource
            {
                Name = "DolPicService",
                DbProvider = _mapper.DataSource.DbProvider,
                ConnectionString = ConfigurationManager.ConnectionStrings["DolPicConn"].ConnectionString
            };
        }

        public static ISqlMapper Instance()
        {
            if (_mapper == null)
            {
                lock (typeof(SqlMapper))
                {
                    if (_mapper == null)
                    {
                        InitMapper();
                    }
                }
            }

            return _mapper;
        }

        public static ISqlMapper Get()
        {
            return Instance();
        }
    }
}
