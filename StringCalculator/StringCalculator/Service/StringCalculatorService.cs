using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.VisualBasic.FileIO;
using System.IO;

namespace StringCalculator.Service
{
    public class StringCalculatorService: IStringCalculatorService
    {
        private ILogger _BBVAStatmentLog;
        private int? _MaxCount = null;
        private List<string> _Delimitors = new List<string>();
        StringBuilder NegativeNumbers;

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
            //This is configurable on how many numbers can be passed for addition.
            //If it is not configured and MaxCount is 0 then we can say unlimited values can be passed.
            if (ConfigurationManager.AppSettings["MaxCount"] != null)
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["MaxCount"].ToString()))
                {
                    this._MaxCount = Convert.ToInt32(ConfigurationManager.AppSettings["MaxCount"].ToString());
                }
            }


            this._Delimitors.Add(Util.DelimComma);
            this._Delimitors.Add(Util.DelimNewline);

        }

             

        public int Add(String Values)
        {
            if(String.IsNullOrEmpty(Values))
            {
                 Console.WriteLine("Enter values to Add:");
                Values = Console.ReadLine();
            }

            int Sum = 0;
            bool isNegativepresent = false;

            StringBuilder formula = new StringBuilder();


            try
            {
                List<object> objects = null;

                if (this._Delimitors.Count() > 0)
                {
                    objects = this.Split(Values);
                }


                if (ValidateCount(objects.Count()))
                {
                    if (objects != null)
                    {
                        if (!ValidateNegativeNumbers(objects))
                        {
                            foreach (object obj in objects)
                            {
                                Sum += Util.if_int(obj, 0);
                                formula.Append(obj.ToString() + "+");
                            }
                        }

                        else
                        {
                            throw new System.InvalidOperationException(string.Format("Values cannot be negative, please correct these values: {0}",NegativeNumbers.ToString().TrimEnd(',')));
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

        private List<object> Split(string Values)
        {
            StringReader sr = new StringReader(Values);
            List<object> splitobjects = new List<object>();

            using (TextFieldParser parser = new TextFieldParser(sr))
            {
                parser.Delimiters = this._Delimitors.ToArray();

                string[] parts = parser.ReadFields();
                foreach (string part in parts)
                {
                    splitobjects.Add(part);
                }

            }

            return splitobjects;
        }


        private bool ValidateCount(int Count)
        {
            bool perform = false;

            if (this._MaxCount != null)
            {
                if (Count <= this._MaxCount)
                {
                    perform = true;
                }
            }

            //When the MaxCount is not defined, we allow unlimited numbers.
            else if (this._MaxCount == null)
            {
                perform = true;
            }

            return perform;
 
        }

        private bool ValidateNegativeNumbers(List<object> objects)
        {
            bool isNegativeNumPresent = false;
            NegativeNumbers = new StringBuilder();

            foreach (object obj in objects)
            {
                if ( Double.Parse(obj.ToString()) < 0)
                {
                    NegativeNumbers.Append(obj.ToString() + ",");
                    isNegativeNumPresent = true;
                }
            }

            return isNegativeNumPresent;
        }
    }
}
