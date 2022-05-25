using System;
using System.Collections.Generic;

namespace Quest
{
    public class Prize
    { 
        private string _text {get;set;}

        public Prize(string someText)
        {
            _text = someText;
        }

        public void ShowPrize(Adventurer frodo)
        {
            if(frodo.Awesomeness > 0){
                for(int x = 0; x < frodo.Awesomeness; x++){
                    Console.WriteLine(_text);
                }
            }else{
                Console.WriteLine("In the immortal words of Mister T 'I pity the fool'");
            }
        }
    }
}