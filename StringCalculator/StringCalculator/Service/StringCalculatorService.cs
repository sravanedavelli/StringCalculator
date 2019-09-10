using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace StringCalculator.Service
{
    public class StringCalculatorService: IStringCalculatorService
    {
        private ILogger _BBVAStatmentLog;
        private int _MaxCount;
        private char[] _Delimitors;

        public StringCalculatorService()
        {
            LoadConfig();
        }

        public StringCalculatorService(ILogger log)
        {
            LoadConfig();
            this._BBVAStatmentLog = log;
        }

        private void LoadConfig()
        {
            if (ConfigurationManager.AppSettings["MaxCount"] != null)
            {
                this._MaxCount = Convert.ToInt32(ConfigurationManager.AppSettings["MaxCount"].ToString());
            }

            if (ConfigurationManager.AppSettings["Delimitors"] != null)
            {
                this._Delimitors = ConfigurationManager.AppSettings["Delimitors"].ToString().Split('|').SelectMany(d => d.ToCharArray()).ToArray();
            }
      
        }

        //Over loaded to play with console input.
        public int Add()
        {
            String Values;
            object[] objects = null;

            Console.WriteLine("Enter values to Add:");
            Values = Console.ReadLine();


            if (this._Delimitors.Count() > 0)
            {

                objects = Values.Split(this._Delimitors);
            }

            int Sum = 0;
            StringBuilder formula = new StringBuilder(); ;

            if (ValidateCount(objects.Count()))
            {
                if (objects != null)
                {
                    foreach (object obj in objects)
                    {
                        Sum += Util.if_int(obj, 0);
                        formula.Append(obj.ToString() + "+");
                    }

                    Console.WriteLine("{0} = {1}", formula.ToString().TrimEnd('+'), Sum);
                }

            }

            else
            {
                Console.WriteLine("Values passed are more than maximum allowed values. Please correct");
            }

            return Sum;
        }

        public int Add(String Values)
        {
            int Sum = 0;
            try
            {
                object[] objects = null;

                if (this._Delimitors.Count() > 0)
                {
                    objects = Values.Split(this._Delimitors);
                }

                StringBuilder formula = new StringBuilder(); 
                if (ValidateCount(objects.Count()))
                {
                    if (objects != null)
                    {
                        foreach (object obj in objects)
                        {
                            Sum += Util.if_int(obj, 0);
                            formula.Append(obj.ToString() + "+");
                        }

                        Console.WriteLine("{0} = {1}", formula.ToString().TrimEnd('+'), Sum);
                    }

                }

                else
                {
                    Console.WriteLine("Values passed are more than maximum allowed values. Please correct");
                }

               
            }

            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }

            return Sum;
        }


        private bool ValidateCount(int Count)
        {
            bool perform = false;

            if (Count <= this._MaxCount)
            {
                perform =  true;
            }

            return perform;
 
        }
    }
}
