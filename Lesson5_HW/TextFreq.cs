using System;
using System.Collections.Generic;
using System.Text;


namespace Lesson5_HW
{
    public class TextFreq
    {
        //  Создать метод, который производит частотный анализ текста.
        //    В качестве параметра в него передается массив слов и текст, 
        //    в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст.
        //    Здесь требуется использовать класс Dictionary
        public Dictionary<string, int> TextFrequenc(string[] arrword, string[] text)
        {
            var tf = new Dictionary<string, int>();
            int count = 0;
            for (int i = 0; i < arrword.Length; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    if (text[j].Equals(arrword[i])) count++;
                }
                if ( !tf.ContainsKey(arrword[i]))
                    tf.Add(arrword[i], count);
                count = 0;
            }
            return tf;
        }
    }

}