using Autokauppa.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Auto.model;

namespace Autokauppa.controller
{

    
    public class KaupanLogiikka
    {
        DatabaseHallinta dbModel = new DatabaseHallinta();

        public bool TestDatabaseConnection()
        {
            bool doesItWork = dbModel.connectDatabase();
            return doesItWork;
        }

        public bool saveAuto(model.Auto newAuto) 
        {
            bool didItGoIntoDatabase = dbModel.saveAutoIntoDatabase(newAuto);
            return didItGoIntoDatabase;
        }

        public List<AutoMerkki> getAllAutoMakers()
        {
            return dbModel.getAllAutoMakersFromDatabase();
        }

        public List<AutoMalli> getAutoModels(int makerId)
        {
            return dbModel.getAutoModelsByMakerId(makerId);
        }
        public void GetModels()
        {
            dbModel.GetCarModels();
        }
    }
}
