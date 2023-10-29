using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Читаем текст из файла
        string text = File.ReadAllText("C:\\Users\\Administrator\\Downloads\\text.txt");

        // Убираем знаки пунктуации
        var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

        // Разбиваем текст на слова
        string[] words = noPunctuationText.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        // Приводим все символы к нижнему регистру
        words = words.Select(word => word.ToLower()).ToArray();

        // Создаем список для хранения слов и их количества
        List<KeyValuePair<string, int>> wordCounts = new List<KeyValuePair<string, int>>();

        foreach (var word in words)
        {
            // Проверяем, есть ли слово в списке
            var existingWord = wordCounts.FirstOrDefault(w => w.Key == word);

            // Обрабатываем прочитанное слово
            if (existingWord.Equals(default(KeyValuePair<string, int>)))
            {
                wordCounts.Add(new KeyValuePair<string, int>(word, 1));
            }
            else
            {
                int index = wordCounts.FindIndex(w => w.Key == word);
                var updatedWord = new KeyValuePair<string, int>(word, existingWord.Value + 1);
                wordCounts[index] = updatedWord;
            }
        }

        // Сортируем список по количеству встречающихся слов
        wordCounts.Sort((x, y) => y.Value.CompareTo(x.Value));

        // Топ-10 наиболее часто встречающихся слов
        for (int i = 0; i < Math.Min(10, wordCounts.Count); i++)
        {
            Console.WriteLine($"Слово \"{wordCounts[i].Key}\" встречается {wordCounts[i].Value} раз");
        }
    }
}
