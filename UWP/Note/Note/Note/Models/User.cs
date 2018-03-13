using System;
using System.Collections.Generic;
using System.Text;

namespace Note.Models
{
    public class User
    {
        public string Name = "Славік";
        public string AvatarUrl= @"https://scontent-frt3-1.xx.fbcdn.net/v/t1.0-9/24993442_721401698057538_830102265302037757_n.jpg?oh=f06a39433302b52696e7c787d87e241b&oe=5B3BC896";
        public string GoogleID;
        public string Pas ;
        public List<Note> Notes;
    }
}
