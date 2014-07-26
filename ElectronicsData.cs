//==================================================
//Copyright (C) 2013
//File Name   :   ElectronicsData.cs
//Author  :   ZhangChao
//Created Date    :   2013-6-19
//Instruction    :  将所有Electronics放到ElectronicsData类中，一条Electronics作为一个对象使用
//Revision History    :
//       
//==================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 决策树
{
    public  class ElectronicsData
    {
        private int rid;
        private string age;
        private string income;
        private string student;
        private string credit_rating;
        private string buy_computer;
        public int Rid { get; set; }
        public string Age { get; set; }
        public string Income { get; set; }
        public string Student { get; set; }
        public string Credit_rating { get; set; }
        public string Buy_computer { get; set; }

        public ElectronicsData(int rid, string age, string income,string student,string credit_rating,string buy_computer)
        {
            Rid = rid;
            Age = age;
            Income = income;
            Student = student;
            Credit_rating = credit_rating;
            Buy_computer = buy_computer;
        }
    }
}
