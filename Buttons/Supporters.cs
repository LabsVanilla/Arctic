using Galaxy.API;
using System;

namespace Galaxy.Buttons
{
    internal class Supporters
    {
        public static void Support(QMNestedButton Info)
        {
            var Supporters = new QMNestedButton(Info, 4, 3, "Galaxy Supporters", "A doller a day can help change a mans life", "Galaxy Supporters");

            var singleButton = new QMSingleButton(Supporters, 2, 0, "This Can Be You", delegate
            {

                Console.WriteLine("Thank You");
            }, "Thank You");

            var Towxrd_Button = new QMSingleButton(Supporters, 1, 0, "Towxrd", delegate
            {
                Console.WriteLine("Thank You");
            }, "Thanks Towxrd Love YA");
        }
    }
}
