using System;

namespace BackendChallengeApi.Core.Model
{
    public class Cliente
    {
        private int _id;
        private string _name;
        private string _cnpj;
        private DateTime _dateCadaster;
        private string _endereco;
        private string _telefone;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }

        } 
        public string Cnpj
        {
            get { return _cnpj; }
            set { _cnpj = value; }
        }
        
        public DateTime DateCadaster
        {
            get { return _dateCadaster;}
            set { _dateCadaster = value;}
        }
        public string Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }
        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }
         
    }
}
