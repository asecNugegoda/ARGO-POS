using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace argo.BL
{
    public class User
    {
        int userId;
        string userName;
        string password;
        string fName;
        string lName;
        string role;
        string contact;
        DateTime bDay;
        int status;
        bool flag;

        public User() { }

        public User(string userName, string password, string fName, string lName, string role, string contact, DateTime bDay, int status, bool flag)
        {
            this.userName = userName;
            this.password = password;
            this.fName = fName;
            this.lName = lName;
            this.role = role;
            this.contact = contact;
            this.bDay = bDay;
            this.status = status;
            this.flag = flag;
        }

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string FName
        {
            get
            {
                return fName;
            }

            set
            {
                fName = value;
            }
        }

        public string LName
        {
            get
            {
                return lName;
            }

            set
            {
                lName = value;
            }
        }

        public string Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value;
            }
        }

        public string Contact
        {
            get
            {
                return contact;
            }

            set
            {
                contact = value;
            }
        }

        public DateTime BDay
        {
            get
            {
                return bDay;
            }

            set
            {
                bDay = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public bool Flag
        {
            get
            {
                return flag;
            }

            set
            {
                flag = value;
            }
        }

        public int UserId
        {
            get
            {
                return userId;
            }

            set
            {
                userId = value;
            }
        }
    }
}
