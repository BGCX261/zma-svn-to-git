using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Zicore.MinecraftAdmin
{
    public class Group 
    {

        public Group()
        {

        }

        Boolean allowBuild = false;

        public Boolean AllowBuild
        {
            get { return allowBuild; }
            set { allowBuild = value; }
        }

        Boolean allowChat = true;

        public Boolean AllowChat
        {
            get { return allowChat; }
            set { allowChat = value; }
        }

        char groupColor = 'F';

        public char GroupColor
        {
            get { return groupColor; }
            set { groupColor = value; }
        }

        bool _ownExecuteResponse = false;

        public bool OwnExecuteResponse
        {
            get { return _ownExecuteResponse; }
            set { _ownExecuteResponse = value; }
        }

        bool _otherExecuteResponse = false;

        public bool OtherExecuteResponse
        {
            get { return _otherExecuteResponse; }
            set { _otherExecuteResponse = value; }
        }

        bool _instantDestroy = false;

        public bool InstantDestroy
        {
            get { return _instantDestroy; }
            set { _instantDestroy = value; }
        }

        bool _allowDestroy = false;

        public bool AllowDestroy
        {
            get { return _allowDestroy; }
            set { _allowDestroy = value; }
        }

        public override string ToString()
        {
            return Name;
        }

        public Group(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

        String _name = "Empty";

        int blockLevel = 1;

        public int BlockLevel
        {
            get { return blockLevel; }
            set { blockLevel = value; }
        }

        public String Name
        {
            get { return _name; }
            set
            { 
                _name = value;
            }
        }

        public Group Self
        {
            get { return this; }
        }

        int _id = 0;

        public int Id
        {
            get { return _id; }
            set 
            { 
                _id = value;
            }
        }

        //bool _isOp = false;

        //public bool Operator
        //{
        //    get { return _isOp; }
        //    set { _isOp = value; }
        //}

        List<String> _commands = new List<string>();

        public List<String> Commands
        {
            get { return _commands; }
            set { _commands = value; }
        }

        public bool IsCommandInList(String name)
        {
            foreach (String s in this.Commands)
            {
                if (s == name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
