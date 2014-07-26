//==================================================
//Copyright (C) 2013
//File Name   :   Program.cs
//Author  :   ZhangChao
//Created Date    :   2013-6-19
//Instruction    :  决策树归纳算法，以p193表6-1作为输入
//Revision History    :
//       
//==================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace 决策树
{
    class Program
    {
        static ArrayList attribute_list = new ArrayList();
        static ArrayList ElectronicsDataList = new ArrayList();
        static Dictionary<string, double> result = new Dictionary<string, double>();
        static ElectronicsData R0 = new ElectronicsData(0, "Age", "Income", "Student", "Credit_rating", "Buy_computer");
        static HashSet<string> j = new HashSet<string>();
        static ArrayList Dj = new ArrayList();
        static void Main(string[] args)
        {
            //初始数据
            #region        
            ElectronicsData R1 = new ElectronicsData(1, "youth", "high", "no", "fair", "no");
            ElectronicsData R2 = new ElectronicsData(2, "youth", "high", "no", "excellent", "no");
            ElectronicsData R3 = new ElectronicsData(3, "middle_aged", "high", "no", "fair", "yes");
            ElectronicsData R4 = new ElectronicsData(4, "senior", "medium", "no", "fair", "yes");
            ElectronicsData R5 = new ElectronicsData(5, "senior", "low", "yes", "fair", "yes");
            ElectronicsData R6 = new ElectronicsData(6, "senior", "low", "yes", "excellent", "no");
            ElectronicsData R7 = new ElectronicsData(7, "middle_aged", "low", "yes", "excellent", "yes");
            ElectronicsData R8 = new ElectronicsData(8, "youth", "medium", "no", "fair", "no");
            ElectronicsData R9 = new ElectronicsData(9, "youth", "low", "yes", "fair", "yes");
            ElectronicsData R10 = new ElectronicsData(10, "senior", "medium", "yes", "fair", "yes");
            ElectronicsData R11 = new ElectronicsData(11, "youth", "medium", "yes", "excellent", "yes");
            ElectronicsData R12 = new ElectronicsData(12, "middle_aged", "medium", "no", "excellent", "yes");
            ElectronicsData R13 = new ElectronicsData(13, "middle_aged", "high", "yes", "fair", "yes");
            ElectronicsData R14 = new ElectronicsData(14, "senior", "medium", "no", "excellent", "no");
            ElectronicsDataList.Add(R1);
            ElectronicsDataList.Add(R2);
            ElectronicsDataList.Add(R3);
            ElectronicsDataList.Add(R4);
            ElectronicsDataList.Add(R5);
            ElectronicsDataList.Add(R6);
            ElectronicsDataList.Add(R7);
            ElectronicsDataList.Add(R8);
            ElectronicsDataList.Add(R9);
            ElectronicsDataList.Add(R10);
            ElectronicsDataList.Add(R11);
            ElectronicsDataList.Add(R12);
            ElectronicsDataList.Add(R13);
            ElectronicsDataList.Add(R14);
            attribute_list.Add("Age");
            attribute_list.Add("Income");
            attribute_list.Add("Student");
            attribute_list.Add("Credit_rating");
            #endregion
            Generate_decision_tree(Dj, attribute_list);
            Console.ReadKey();
        }

        /// <summary>
        /// 计算Info(D)，D的熵
        /// </summary>
        public static double DEntropy()
        {
            double result = 0.0d;
            double count = ElectronicsDataList.Count;
            double countYes = 0;
            foreach (ElectronicsData data in ElectronicsDataList)
            {
                if (data.Buy_computer == "yes")
                {
                    countYes++;
                }
            }
            double countNo = count - countYes;
            result = -(countYes / count) * Math.Log(countYes / count, 2) - (countNo / count) * Math.Log(countNo / count, 2);
            return result;
        }

        /// <summary>
        /// 计算基于Age划分对D的元祖分类所需要的期望信息
        /// </summary>
        public static double AgeGain(out string propetry)
        {
            propetry = "Age";
            double result = 0.0d;
            double countYes = 0.0d;
            double countNo = 0.0d;
            double countAll = ElectronicsDataList.Count;
            HashSet<string> propetryDetail = new HashSet<string>();
            foreach (ElectronicsData data in ElectronicsDataList)
            {
                propetryDetail.Add(data.Age);
            }
            foreach (string item in propetryDetail)
            {
                foreach (ElectronicsData data in ElectronicsDataList)
                {
                    if (data.Age == item && data.Buy_computer == "yes")
                    {
                        countYes++;
                    }
                    else if (data.Age == item && data.Buy_computer == "no")
                    {
                        countNo++;
                    }
                }
                if (countYes == 0.0d)
                {
                    result += (countYes + countNo) / countAll *(- (countNo / (countYes + countNo))) * Math.Log((countNo / (countYes + countNo)), 2); 
                }
                if (countNo == 0.0d)
                {
                    result += (countYes + countNo) / countAll * (-(countYes / (countYes + countNo))) * Math.Log((countYes / (countYes + countNo)), 2); 
                }
                else if (countYes != 0.0d && countNo != 0.0d)
                { 
                    result += (countYes + countNo) / countAll * ((-countYes / (countYes + countNo)) * Math.Log((countYes / (countYes + countNo)), 2) - (countNo / (countYes + countNo)) * Math.Log((countNo / (countYes + countNo)), 2)); 
                }
                countYes =countNo= 0.0d;
            }
            return DEntropy()-result;
        }

        /// <summary>
        /// 计算基于Income划分对D的元祖分类所需要的期望信息
        /// </summary>
        public static double IncomeGain(out string propetry)
        {
            propetry = "Income";
            double result = 0.0d;
            double countYes = 0.0d;
            double countNo = 0.0d;
            double countAll = ElectronicsDataList.Count;
            HashSet<string> propetryDetail = new HashSet<string>();
            foreach (ElectronicsData data in ElectronicsDataList)
            {
                propetryDetail.Add(data.Income);
            }
            foreach (string item in propetryDetail)
            {
                foreach (ElectronicsData data in ElectronicsDataList)
                {
                    if (data.Income == item && data.Buy_computer == "yes")
                    {
                        countYes++;
                    }
                    else if (data.Income == item && data.Buy_computer == "no")
                    {
                        countNo++;
                    }
                }
                if (countYes == 0.0d)
                {
                    result += (countYes + countNo) / countAll * (-(countNo / (countYes + countNo))) * Math.Log((countNo / (countYes + countNo)), 2);
                }
                if (countNo == 0.0d)
                {
                    result += (countYes + countNo) / countAll * (-(countYes / (countYes + countNo))) * Math.Log((countYes / (countYes + countNo)), 2);
                }
                else if (countYes != 0.0d && countNo != 0.0d)
                {
                    result += (countYes + countNo) / countAll * ((-countYes / (countYes + countNo)) * Math.Log((countYes / (countYes + countNo)), 2) - (countNo / (countYes + countNo)) * Math.Log((countNo / (countYes + countNo)), 2));
                }
                countYes = countNo = 0.0d;
            }
            return DEntropy() - result;
        }

        /// <summary>
        /// 计算基于Student划分对D的元祖分类所需要的期望信息
        /// </summary>
        public static double StudentGain(out string propetry)
        {
            propetry = "Student";
            double result = 0.0d;
            double countYes = 0.0d;
            double countNo = 0.0d;
            double countAll = ElectronicsDataList.Count;
            HashSet<string> propetryDetail = new HashSet<string>();
            foreach (ElectronicsData data in ElectronicsDataList)
            {
                propetryDetail.Add(data.Student);
            }
            foreach (string item in propetryDetail)
            {
                foreach (ElectronicsData data in ElectronicsDataList)
                {
                    if (data.Student == item && data.Buy_computer == "yes")
                    {
                        countYes++;
                    }
                    else if (data.Student == item && data.Buy_computer == "no")
                    {
                        countNo++;
                    }
                }
                if (countYes == 0.0d)
                {
                    result += (countYes + countNo) / countAll * (-(countNo / (countYes + countNo))) * Math.Log((countNo / (countYes + countNo)), 2);
                }
                if (countNo == 0.0d)
                {
                    result += (countYes + countNo) / countAll * (-(countYes / (countYes + countNo))) * Math.Log((countYes / (countYes + countNo)), 2);
                }
                else if (countYes != 0.0d && countNo != 0.0d)
                {
                    result += (countYes + countNo) / countAll * ((-countYes / (countYes + countNo)) * Math.Log((countYes / (countYes + countNo)), 2) - (countNo / (countYes + countNo)) * Math.Log((countNo / (countYes + countNo)), 2));
                }
                countYes = countNo = 0.0d;
            }
            return DEntropy() - result;
        }

        /// <summary>
        /// 计算基于Credit_rating划分对D的元祖分类所需要的期望信息
        /// </summary>
        public static double Credit_ratingGain(out string propetry)
        {
            propetry = "Credit_rating";
            double result = 0.0d;
            double countYes = 0.0d;
            double countNo = 0.0d;
            double countAll = ElectronicsDataList.Count;
            HashSet<string> propetryDetail = new HashSet<string>();
            foreach (ElectronicsData data in ElectronicsDataList)
            {
                propetryDetail.Add(data.Credit_rating);
            }
            foreach (string item in propetryDetail)
            {
                foreach (ElectronicsData data in ElectronicsDataList)
                {
                    if (data.Credit_rating == item && data.Buy_computer == "yes")
                    {
                        countYes++;
                    }
                    else if (data.Credit_rating == item && data.Buy_computer == "no")
                    {
                        countNo++;
                    }
                }
                if (countYes == 0.0d)
                {
                    result += (countYes + countNo) / countAll * (-(countNo / (countYes + countNo))) * Math.Log((countNo / (countYes + countNo)), 2);
                }
                if (countNo == 0.0d)
                {
                    result += (countYes + countNo) / countAll * (-(countYes / (countYes + countNo))) * Math.Log((countYes / (countYes + countNo)), 2);
                }
                else if (countYes != 0.0d && countNo != 0.0d)
                {
                    result += (countYes + countNo) / countAll * ((-countYes / (countYes + countNo)) * Math.Log((countYes / (countYes + countNo)), 2) - (countNo / (countYes + countNo)) * Math.Log((countNo / (countYes + countNo)), 2));
                }
                countYes = countNo = 0.0d;
            }
            return DEntropy() - result;
        }

        /// <summary>
        /// 判断Class的结果是否全部为一相同值
        /// </summary>
        public static bool IsAllSameClass(ArrayList TempList,out string yesOrNo)
        {
            int markYes = 0;
            int markNo = 0;
            bool mark = false; 
            foreach (ElectronicsData data in TempList)
            {
                if (data.Buy_computer == "yes")
                {
                    markYes = 1;
                    mark=true;
                }
                else if (data.Buy_computer == "no")
                {
                    markNo = 1;
                    mark = false;
                }        
            }
            if (markNo == markYes)
            {
                yesOrNo = null;
                return false;
            }
            else
            {
                if (mark)
                    yesOrNo = "yes";
                else
                    yesOrNo = "no";
                return true;
            }
        }

        /// <summary>
        /// 计算分裂属性
        /// </summary>
        public static string GetSplitPropetry(Dictionary<string, double> result)
        {
            string age, income, credit_rating, student;
            double ageGain, incomeGain, credit_ratingGain, studentGain;
            ageGain = AgeGain(out age);
            incomeGain = IncomeGain(out income);
            credit_ratingGain = Credit_ratingGain(out credit_rating);
            studentGain = StudentGain(out student);
            if (!result.ContainsKey(age))
            {
                result.Add(age, ageGain);
            }
            if (!result.ContainsKey(income))
            {
                result.Add(income, incomeGain); 
            }
            if (!result.ContainsKey(credit_rating))
            {
                result.Add(credit_rating, credit_ratingGain); 
            }
            if (!result.ContainsKey(student))
            {
                result.Add(student, studentGain); 
            }
            string key = "";
            double value = double.Epsilon;
            foreach (string s in result.Keys)
            {
                if (result[s] > value)
                {
                    value = result[s];
                    key = s;
                }
            }
            return key;
        }

        /// <summary>
        /// 产生最优解
        /// </summary>
        public static string attribute_selection_method(ArrayList ElectronicsDataList, ArrayList attribute_list)
        {
            string s = GetSplitPropetry(result);
            result.Clear();
            return s;
            //Todo
        }

        public static DecisionTree Generate_decision_tree(ArrayList TempDataList, ArrayList attribute_list)
        {
            DecisionTree tree = new DecisionTree();
            string c=null;      
            if (IsAllSameClass(ElectronicsDataList,out c))
            {
                tree.Name = c;
                return tree;
            }
            if (attribute_list.Count == 0)
            {
                double countYes = 0;
                double countNo = 0;
                foreach (ElectronicsData data in ElectronicsDataList)
                {
                    if (data.Buy_computer == "yes")
                    {
                        countYes++;
                    }
                    if (data.Buy_computer == "no")
                    {
                        countNo++;
                    }
                }
                if (countYes > countNo)
                {
                    tree.Name = "yes";
                }
                else
                {
                    tree.Name = "no";
                }
                return tree;
            }
            string splitting_criterion = attribute_selection_method(ElectronicsDataList, attribute_list);
            attribute_list.Remove(splitting_criterion);
            if (R0.Age.Equals(splitting_criterion))
            {
                foreach (ElectronicsData s in ElectronicsDataList)
                {
                    j.Add(s.Age);
                }
            }
            if (R0.Income.Equals(splitting_criterion))
            {
                foreach (ElectronicsData s in ElectronicsDataList)
                {
                    j.Add(s.Income);
                }
            }
            if (R0.Student.Equals(splitting_criterion))
            {
                foreach (ElectronicsData s in ElectronicsDataList)
                {
                    j.Add(s.Student);
                }
            }
            else if (R0.Credit_rating.Equals(splitting_criterion))
            {
                foreach (ElectronicsData s in ElectronicsDataList)
                {
                    j.Add(s.Credit_rating);
                }
            }
            result.Add(splitting_criterion, 0.0f);
            foreach (string item in j)
            {         
                foreach (ElectronicsData data in ElectronicsDataList)
                {
                    if (data.Age.Equals(item) || data.Income.Equals(item) || data.Credit_rating.Equals(item) || data.Student.Equals(item))
                    {
                        Dj.Add(data);
                    }
                } 
                if (item==null)
                {
                    //加一个树叶到节点N，标记为D中的多数类
                }
                else
                {
                    DecisionTree n = new DecisionTree();
                    //此时计算的分裂节点还是age，出现循环递归
                    n = Generate_decision_tree(Dj, attribute_list);
                    tree.Next.Add(item, n);
                    Dj.Clear();
                } 
            }
            return tree;
        }
    }
}
