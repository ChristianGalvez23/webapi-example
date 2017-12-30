using System.Collections.Generic;
using System.IO;
using System.Linq;
using EventsPlace.Persistence.Entities;

namespace EventsPlace.Persistence.StorageMechanism {
    public class Mechanism<T> where T : EntityBase {
        private string fileUrl;
        private FileStream fs;

        public Mechanism () {
            if (typeof (T) == typeof (Product)) {
                this.fileUrl = "products_bd.txt";
            } else {
                this.fileUrl = "animals_bd.txt";
            }
        }

        public void WriteInFile (string json) {
            Initialize ();
            StreamWriter sw = new StreamWriter (this.fs);
            sw.WriteLine (json);
            sw.Close ();
            this.fs.Close ();
        }

        public void DeleteLineAt (int i) {
            var allLines = ReadFile ();
            allLines.RemoveAt (i);
            File.WriteAllLines (this.fileUrl, allLines);
        }
        public List<string> ReadFile () {
            return File.ReadAllLines (this.fileUrl).ToList ();
        }

        private void Initialize () {
            if (!File.Exists (fileUrl)) {
                fs = new FileStream (fileUrl, FileMode.CreateNew);
            } else {
                fs = new FileStream (fileUrl, FileMode.Append);
            }
        }
    }
}