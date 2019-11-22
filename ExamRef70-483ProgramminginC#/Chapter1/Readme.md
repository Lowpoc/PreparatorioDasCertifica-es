# Manage program flow

If you could build only programs that execute all their
logic from top to bottom, it would not be feasible to
build complex applications. Fortunately, C# and the .NET
Framework offer you a lot of options for creating complex
programs that don’t have a fixed program flow.
This chapter starts with looking at how to create multithreaded applications. Those applications can scale well
and remain responsive to the user while doing their work.
You will also look at the new language feature async/
await that was added to C# 5.
You will learn about the basic C# language constructs
to make decisions and execute a piece of code multiple times, depending on the circumstances. These constructs form the basic language blocks of each application, and you will
use them often.
After that, you will learn how to create applications that are loosely coupled by using delegates and events. With events, you can build objects that can notify each other
when something happens and that can respond to those notifications. Frameworks such
as ASP.NET, Windows Presentation Foundation (WPF), and WinForms make heavy use of
events; understanding events thoroughly will help you build great applications.
Unfortunately, your program flow can also be interrupted by errors. Such errors can happen in areas that are out of your control but that you need to respond to. Sometimes you
want to raise such an error yourself. You will learn how exceptions can help you implement
a robust error-handling strategy in your applications.


## Objectives in this chapter:
 - [Objective 1.1: Implement multithreading and asynchronous processing](https://github.com/Lowpoc/PreparatorioDasCertificacoes/tree/master/ExamRef70-483ProgramminginC%23/Chapter1/ManageProgamFlow/ImplementMultTreadingAndAsynchronousProcessing)
 - [Objective 1.2: Manage multithreading](https://github.com/Lowpoc/PreparatorioDasCertificacoes/tree/master/ExamRef70-483ProgramminginC%23/Chapter1/ManageMultithreading/)
 - [Objective 1.3: Implement program flow](https://github.com/Lowpoc/PreparatorioDasCertificacoes/tree/master/ExamRef70-483ProgramminginC%23/Chapter1/ImplementProgramFlow/)
 - [Objective 1.4: Create and implement events and callbacks](https://github.com/Lowpoc/PreparatorioDasCertificacoes/tree/master/ExamRef70-483ProgramminginC%23/Chapter1/CreateAndImplementEventAndCallBacks/)
 - [Objective 1.5. Implement exception handling](https://github.com/Lowpoc/PreparatorioDasCertificacoes/tree/master/ExamRef70-483ProgramminginC%23/Chapter1/ImplementExceptionHandling/)


References:
- [Exam Ref 70-483](https://ptgmedia.pearsoncmg.com/images/9780735676824/samplepages/9780735676824.pdf)