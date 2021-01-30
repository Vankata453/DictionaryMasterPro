using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary_MasterPro
{
    class Program
    {
        static SortedDictionary<string, SortedDictionary<string, string>> dictionaries = 
            new SortedDictionary<string, SortedDictionary<string, string>>();
        static string selectedDictionaryName = "";
        static void Main()
        {
            programStartup();

            string[] input = Console.ReadLine().Split();

            while (true)
            {
                if (input[0] == "?")
                {
                    printHelp();
                }
                else if (input[0] == "new")
                {
                    newDictionary(input[1]);

                    Console.WriteLine();
                    Console.WriteLine("TIP: Start adding stuff with 'add [key] - [value]'.");
                    Console.WriteLine("TIP: Delete stuff with 'del (or 'delete') [keyOrValue]'.");
                    Console.WriteLine("TIP: Select another dictionary with 'select [dictionaryName]'!");
                    Console.WriteLine("TIP: List the selected dictionary with 'list'.");
                    Console.WriteLine();

                    break;
                }
                else if (input[0] == "end!!!")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please type a valid command: 'new [name]' (new dictionary) or '?' (help)");
                }

                input = Console.ReadLine().Split();
            }

            if (input[0] != "end!!!")
            {
                List<string> action = Console.ReadLine().Split().ToList();

                while (action[0] != "end!!!")
                {
                    switch (action[0])
                    {
                        case "new":

                            newDictionary(action[1]);

                            break;

                        case "add":

                            action.RemoveAt(0);

                            string[] keyAndValue = string.Join(" ", action).Split(" - ");

                            addToDictionary(keyAndValue[0], keyAndValue[1]);

                            break;

                        case "addBatch":

                            Console.WriteLine();

                            string keyOrOtherInput = Console.ReadLine();

                            while (keyOrOtherInput != "end")
                            {
                                string value = Console.ReadLine();

                                addToDictionary(keyOrOtherInput, value);

                                Console.WriteLine();

                                keyOrOtherInput = Console.ReadLine();
                            }

                            Console.WriteLine("Exiting batch...");

                            Console.WriteLine();

                            break;

                        case "select":

                            if (dictionaries.ContainsKey(action[1]))
                            {
                                selectedDictionaryName = action[1];

                                Console.WriteLine($"Dictionary {selectedDictionaryName} selected!");
                            }
                            else
                            {
                                Console.WriteLine("This dictionary doesn't exist.");
                            }

                            Console.WriteLine();

                            break;

                        case "rename":

                            renameDictionary(action[1]);

                            break;

                        case "list":

                            listDictionary();

                            break;

                        case "?":

                            printHelp();

                            break;

                        default:

                            if (action[0] == "del" || action[0] == "delete")
                            {
                                deleteFromDictionary(action[1]);
                            }
                            else
                            {
                                Console.WriteLine("Please type a valid command. Type '?' for help!");

                                Console.WriteLine();
                            }

                            break;
                    }

                    action = Console.ReadLine().Split().ToList();
                }
            }

            Console.WriteLine("Exiting Dictionary MasterPro!");
        }

        static void programStartup()
        {
            Console.WriteLine("Dictionary MasterPro 1.0 (2020)");
            Console.WriteLine("TIP: Type 'new [name]' (new dictionary) or '?' (help) to " +
                "get started!");
            Console.WriteLine();
            Console.WriteLine("What do you want to do?");
            Console.WriteLine();
        }

        static void newDictionary(string name)
        {
            if (!dictionaries.ContainsKey(name))
            {
                dictionaries.Add(name, new SortedDictionary<string, string>());
                selectedDictionaryName = name;

                Console.WriteLine($"Dictionary {name} succesfully created!");
                Console.WriteLine($"Dictionary {name} is currently selected!");
            }
            else
            {
                Console.WriteLine("Dictionary with this name already exists! Action aborted.");
            }

            Console.WriteLine();
        }

        static void addToDictionary(string key, string value)
        {
            if (!dictionaries[selectedDictionaryName].ContainsKey(key))
            {
                dictionaries[selectedDictionaryName].Add(key, value);

                Console.WriteLine("Object succesfully added!");
            }
            else
            {
                Console.WriteLine("Object already exists in dictionary! Action aborted.");
            }

            Console.WriteLine();
        }

        static void deleteFromDictionary(string keyOrValue)
        {
            if (dictionaries[selectedDictionaryName].ContainsKey(keyOrValue))
            {
                if (dictionaries[selectedDictionaryName].Remove(keyOrValue))
                {
                    Console.WriteLine($"{keyOrValue} (key) succesfully removed from {selectedDictionaryName}!");
                }
                else
                {
                    Console.WriteLine($"Error when removing {keyOrValue} (key) from {selectedDictionaryName}!");
                }
            }
            else if (dictionaries[selectedDictionaryName].ContainsValue(keyOrValue))
            {
                dictionaries[selectedDictionaryName].
                    Remove(dictionaries[selectedDictionaryName].
                    First(x => x.Value == keyOrValue).Key);

                Console.WriteLine($"First instance of {keyOrValue} (value) " +
                    $"succesfully removed from {selectedDictionaryName}!");
            }
            else
            {
                Console.WriteLine("Object doesn't exist in dictionary!");
            }

            Console.WriteLine();
        }
        
        static void renameDictionary(string newName)
        {
            if (!dictionaries.ContainsKey(newName))
            {
                SortedDictionary<string, string> data = dictionaries[selectedDictionaryName];
                dictionaries.Remove(selectedDictionaryName);
                dictionaries.Add(newName, data);
                selectedDictionaryName = newName;

                Console.WriteLine($"Dictionary renamed to {newName}!");
            }
            else
            {
                Console.WriteLine("Dictionary with this name already exists! Action aborted.");
            }

            Console.WriteLine();
        }

        static void listDictionary()
        {
            Console.WriteLine();

            Console.WriteLine($"Contents of {selectedDictionaryName}:");

            foreach (var currObj in dictionaries[selectedDictionaryName])
            {
                Console.WriteLine($" {currObj.Key} - {currObj.Value}");
            }

            Console.WriteLine();
        }

        static void printHelp()
        {
            Console.WriteLine();

            Console.WriteLine("'new [name]' - Creates a new dictionary.");

            if (dictionaries.Keys.Count != 0)
            {
                Console.WriteLine("'add [key] - [value]' - Adds stuff to the selected dictionary.");
                Console.WriteLine("'del (or 'delete') [keyOrValue]' - Deletes stuff from the selected dictionary.");
                Console.WriteLine("'rename [newName]' - Renames the selected dictionary to the specified new name.");
                Console.WriteLine("'select [dictionaryName]' - Selects another dictionary.");
                Console.WriteLine("'list' - Lists the selected dictionary.");
            }

            Console.WriteLine("'end!!!' - Exits Dictionary MasterPro");
            Console.WriteLine("'?' - Shows Dictionary MasterPro help!");

            Console.WriteLine();
        }
    }
}
