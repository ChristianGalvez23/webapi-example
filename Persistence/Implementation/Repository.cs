using System;
using System.Collections.Generic;
using System.Linq;
using EventsPlace.Persistence.Entities;
using EventsPlace.Persistence.Interfaces;
using EventsPlace.Persistence.StorageMechanism;
using Newtonsoft.Json;

namespace EventsPlace.Persistence.Implementation {
    public class Repository<T> : IRepository<T> where T : Persistence.Entities.EntityBase {
        protected Mechanism<T> db;

        public Repository () {
            this.db = new Mechanism<T> ();
        }

        public void Insert (T entitie) {
            string jsonObj = JsonConvert.SerializeObject (entitie);
            try {
                this.db.WriteInFile (jsonObj);
            } catch (Exception err) {
                throw new Exception ("Error Adding Json Object to File.", err);
            }
        }
        public void Update (T entitie) {
            this.Delete (entitie.Id);
            Insert (entitie);
        }

        public void Delete (int id) {
            var list = SelectAll ();
            int i = list.FindIndex (0, list.Count - 1, e => e.Id == id);
            if (i == -1) {
                throw new Exception ("No Id found.");
            }
            this.db.DeleteLineAt (i);
        }

        public List<T> SelectAll () {
            List<string> jsonList = this.db.ReadFile ();
            List<T> convertedList = new List<T> ();
            try {
                jsonList.ForEach (p => convertedList.Add (JsonConvert.DeserializeObject<T> (p)));
            } catch (Exception err) {
                throw new JsonException ("Error Deserializing Objects.", err);
            }
            return convertedList;
        }
    }
}