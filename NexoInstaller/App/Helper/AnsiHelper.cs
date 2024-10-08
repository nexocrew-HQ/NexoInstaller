﻿using Spectre.Console;

namespace McCreate.App.Helper;

public class AnsiHelper
{
    public static void ConfirmSelection(string text, string item)
    {
        AnsiConsole.MarkupLine($"[blue]-[/] [white]{text}: [/][yellow]{item}[/][white].[/]");
    }

    public static string QuestionFormat(string question)
    {
        return $"[yellow]?[/] [white]{question}[/]";
    }

    public static void Title(string style)
    {
        AnsiConsole.MarkupLine($"[{style}]                                   _       [/]");
        AnsiConsole.MarkupLine($"[{style}]                                  | |      [/]");
        AnsiConsole.MarkupLine($"[{style}] _ __ ___   ___ ___ _ __ ___  __ _| |_ ___ [/]");
        AnsiConsole.MarkupLine($"[{style}]| '_ ` _ \\ / __/ __| '__/ _ \\/ _` | __/ _ \\[/]");
        AnsiConsole.MarkupLine($"[{style}]| | | | | | (_| (__| | |  __/ (_| | ||  __/[/]");
        AnsiConsole.MarkupLine($"[{style}]|_| |_| |_|\\___\\___|_|  \\___|\\__,_|\\__\\___|[/]");

    }

    public static void Success(string message)
    {
        AnsiConsole.MarkupLine($"[green]\u2713[/] [white]{message}[/]");
    }

    public static void Info(string message)
    {
        AnsiConsole.MarkupLine($"[turquoise2]i[/] [white]{message}[/]");
    }
    
    public static void Error(string message)
    {
        AnsiConsole.MarkupLine($"[red]x[/] [red]{message}[/]");
    }
    
}