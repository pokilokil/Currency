using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Xml;

namespace Currency
{
    public class CurrencyConverter
    {
        private string _name = "hello";
        private string apikey = "fadsfaf35235234efw32";
        /// <summary>
        /// главная функция. возвращает курс валюты
        /// функция - это просто название куска кода, параметры и тд
        /// метод - привязанная к классу фукнция (метод класса CurrencyConverter)
        /// </summary>
        /// <param name="currency">три буквы валюты</param>
        /// <returns>ЧИСЛО курса</returns>
        public double mainConverter(string currency)
        {
            string line = returnLineFromCBR();

            double result = InternetSearch(line, currency);

            return result;
        }
        //получаем строку из ЦБ. приват - пользователю это не надо
        private string returnLineFromCBR()
        {
            string url = "http://www.cbr.ru/scripts/XML_daily.asp";
            WebResponse response = null;
            StreamReader strReader = null;
            WebRequest request = WebRequest.Create(url);
            response = request.GetResponse();
            strReader = new StreamReader(response.GetResponseStream());
            string line = strReader.ReadToEnd();
            response.Close();

            return line;
        }
        //ищем в строке валютут - приват, пользователю это не надо тоже
        private double InternetSearch(string line, string courceof)
        {
            int posUSD = line.IndexOf(courceof);//ищем USD
            int positionValue = line.IndexOf("Value", posUSD);
            int posBeginCourse = positionValue + 6;
            string course = line.Substring(posBeginCourse, 7);
            double courceUSD = Convert.ToDouble(course);
            return courceUSD;
        }
    }
}