//==================================================
//Copyright (C) 2013
//File Name   :   Program.cs
//Author  :   ZhangChao
//Created Date    :   2013-6-20
//Instruction    :  决策树定义
//Revision History    :
//       
//==================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 决策树
{
    public class DecisionTree
    {
        public string Name;
        public Dictionary<string, DecisionTree> Next;
    }
}
