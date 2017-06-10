using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHMIS.Model
{
    public class Message
    {
        public Message()

        {


        }

        private string _messageID;
        private string _body;
        private string _subject;
        private string _to;
        private string _from;
        private string _date;
        private string _created;
        private string _orgID;
        private string _sent;
        private string _type;
        private string _contact;
        private string _email;
        private string _taskID;
        private string orgID;
        public string MessageID
        {
            get
            {
                return _messageID;
            }

            set
            {
                _messageID = value;
            }
        }
        private string _action;

        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }


        public string Body
        {
            get
            {
                return _body;
            }

            set
            {
                _body = value;
            }
        }

        public string Subject
        {
            get
            {
                return _subject;
            }

            set
            {
                _subject = value;
            }
        }

        public string To
        {
            get
            {
                return _to;
            }

            set
            {
                _to = value;
            }
        }

        public string From
        {
            get
            {
                return _from;
            }

            set
            {
                _from = value;
            }
        }

        public string Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
            }
        }

        public string Created
        {
            get
            {
                return _created;
            }

            set
            {
                _created = value;
            }
        }

        public string OrgID
        {
            get
            {
                return _orgID;
            }

            set
            {
                _orgID = value;
            }
        }

        public string Sent
        {
            get
            {
                return _sent;
            }

            set
            {
                _sent = value;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public string Contact
        {
            get
            {
                return _contact;
            }

            set
            {
                _contact = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public string TaskID
        {
            get
            {
                return _taskID;
            }

            set
            {
                _taskID = value;
            }
        }

        public string OrgID1
        {
            get
            {
                return orgID;
            }

            set
            {
                orgID = value;
            }
        }
    }
}