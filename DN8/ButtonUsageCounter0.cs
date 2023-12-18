/*
 * Created by SharpDevelop.
 * User: Karl Rege
 * Date: 03.08.2023
 * Time: 15:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;

namespace DN8 {
	
	public class ButtonUsageCounter : IDisposable  {
        public const string CategoryName = "Button Usage";
        public PerformanceCounter RegisterClicks;
        public PerformanceCounter UpdateClicks;

        public ButtonUsageCounter() {
            Dispose();
            if (!PerformanceCounterCategory.Exists(CategoryName)) {
                

                CounterCreationData UpdateButtonClick = new CounterCreationData();
                UpdateButtonClick.CounterName = "UpdateClick";
                UpdateButtonClick.CounterType = PerformanceCounterType.NumberOfItems32;
                UpdateButtonClick.CounterHelp = "How many time Leave button is clicked. Useful to know how many customers left for a given time";
                
                CounterCreationData RegButtonClick = new CounterCreationData();
                RegButtonClick.CounterName = "RegisterClick";
                RegButtonClick.CounterType = PerformanceCounterType.NumberOfItems32;
                RegButtonClick.CounterHelp = "How many time Register button is clicked. Useful to know how many customers registered for a given time";
                
   
                
                // Create Collection of CreationData 
                CounterCreationDataCollection ClickCounters = new CounterCreationDataCollection();
                ClickCounters.Add(RegButtonClick);
                ClickCounters.Add(UpdateButtonClick);

                // Create new Performance counter Category
                PerformanceCounterCategory.Create(ButtonUsageCounter.CategoryName, "Various click counter on the Form. Used to weigh each button in this form",
                    PerformanceCounterCategoryType.SingleInstance, ClickCounters);

                // Now create actual measuring counters
                RegisterClicks = new PerformanceCounter(CategoryName, "RegisterClick", false);
                UpdateClicks = new PerformanceCounter(CategoryName, "UpdateClick", false);
                
} else {
				RegisterClicks = new PerformanceCounter(CategoryName, "RegisterClick", false);
				UpdateClicks = new PerformanceCounter(CategoryName, "UpdateClick", false);
                
           }
        }
        public void Dispose() {
            if (PerformanceCounterCategory.Exists(CategoryName)) {
                PerformanceCounterCategory.Delete(CategoryName);
            }
        }
    }
	class Program
	{
		public static void Main(string[] args)
		{
			ButtonUsageCounter counter = new ButtonUsageCounter();
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}