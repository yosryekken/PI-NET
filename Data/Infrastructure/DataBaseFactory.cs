using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class DataBaseFactory : IDataBaseFactory
    {
        private SinistreContext dataContext;

        public SinistreContext DataContext
        {
            get { return dataContext; }
            
        }
        public DataBaseFactory()
        {
            dataContext = new SinistreContext();
        }
    }

