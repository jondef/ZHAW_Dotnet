using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace DN6 {
    public class Contact {
        public String Name {get;set;}
        public String Kurz {get;set;}
        public String Standort{get;set;}
        public String Kategorie{get;set;}
        public String EMail{get;set;}
        public String Tel{get;set;}
        public String Departement{get;set;}
        
        public override String ToString() {
            return Name + ";" + Kurz + ";" + Standort + ";" + Kategorie + ";" + EMail + ";" + Tel + ";" + Departement + ";";
        }
        
        public String ToVcf () {
            return "BEGIN:VCARD\n" +
                "VERSION:3.0\n" +
                "N:" + Name + "\n" +
                "FN:" + Name + "\n" +
                "ORG:" + Departement + "\n" +
                "TEL;TYPE=WORK,VOICE:" + Tel + "\n" +
                "EMAIL;TYPE=PREF,INTERNET:" + EMail + "\n" +
                "END:VCARD";
        }

        public IEnumerator<String> GetEnumerator() {
            yield return Name;
            yield return Kurz;
            yield return Standort;
            yield return Kategorie;
            yield return EMail;
            yield return Tel;
            yield return Departement;
        }

        public Contact(string name, string kurz, string standort, string kategorie, string eMail, string tel, string dep)  {
            Name = name;
            Kurz = kurz;
            Standort = standort;
            Kategorie = kategorie;
            EMail = eMail;
            Tel = tel;
            Departement = dep;
        }

        public int CompareTo(Contact other) {
            return String.Compare(Name, other.Name, StringComparison.Ordinal);
        }

    }
}