# School of Computing &mdash; Year 4 Project Proposal Form

> Edit (then commit and push) this document to complete your proposal form.
> Make use of figures / diagrams where appropriate.
>
> Do not rename this file.

## SECTION A

|                     |                   |
|---------------------|-------------------|
|Project Title:       | Mini-mental State Examintaion|
|Student 1 Name:      | Matthew Nolan     |
|Student 1 ID:        | 16425716          |
|Student 2 Name:      | Micheal O'Hara    |
|Student 2 ID:        | 16414554          |
|Project Supervisor:  | xxxxxx            |

> Ensure that the Supervisor formally agrees to supervise your project; this is only recognised once the
> Supervisor assigns herself/himself via the project Dashboard.
>
> Project proposals without an assigned
> Supervisor will not be accepted for presentation to the Approval Panel.

## SECTION B

> Guidance: This document is expected to be approximately 3 pages in length, but it can exceed this page limit.
> It is also permissible to carry forward content from this proposal to your later documents (e.g. functional
> specification) as appropriate.
>
> Your proposal must include *at least* the following sections.


### Introduction

> Describe the general area covered by the project.

Our project is based off the Mini-mental state examination (MMSE). 
The MMSE is a 30-point questionnaire which is used in clinical and research practices to measure cognitive impairment in patients, also in medicine to screen for dementia.
The purpose of the exam is to estimate the severity and progression of cognitive impairment and to follow the course of cognitive changes in a patient over time. Our idea is to modernize the test by making an application which can be used in each of the above mention fields.
The application will allow for the MMSE to be administered and taken by patients with varying level of cognitive ability within different environments. If the project is successful it could be used by medical professionals in order to reduce time spent doing these tests with pen and paper and allow for quicker processing of results.

### Outline

> Outline the proposed project.

Our project would be a full stack application for carrying out,processing and graphing the results of the Mini Mental State Exam (MMSE). The application will have two interfaces, one for medical professionals and one for patients.In relation to
the interface for the  medical professionals we will focus on efficiently gathering,handling and presenting patient data.Whereas for the patient's interface we will focus on accessiblity and usability of the application due to the varying levels of impairments within the user group. 




### Background

> Where did the ideas come from?

As it stands right now the test is carried out with pen and paper and can take time to process the results in order to determine the serverity of the cognitive impairment. The medical professionals then have to store the physical copy of the test and result of the test.
From speaking to people in the field we found that this can be quite cumbersome and frustrating. 
With the new improvement in technolgoy and how all business and sectors in life are moving to be more modern, we decied we would try to convert this test from using paper and pens to using the newer more modern technolgoys avalibale to us such as computers, laptops and tablets.


### Achievements

> What functions will the project provide? Who will the users be?

The project will be used by doctors and nurses dealing with patients of cognitive impairment.
It will allow for easier testing of the progression of the impairment and easy storing and accessing of the results of the tests.
As it stands the test is done with pen and paper and this can be time consuming and can be cumbersome to store and keep track of the results of previous tests. 
Our application would allow for quicker testing and then the ability to graph the results and possibly track the progression of the cognitive impairment.
It will also allow for a joint user interaction between the tester and the patient if for example the patient has poor motor skill and thus cannot type but can still verbally answer, then the tester could do the typing for the patient

### Justification

> Why/when/where/how will it be useful?

This would be useful to doctors and nurses who are dealing with patients of cognitive impairment and wish to determine the severity of the impairment.
It would also be useful for tracking the progression of the impairment to see if the patients brain and motor function is 
going to deteriorate rapidly or slowly over time. 
This could then be further used to determine the type of treatment the patient should undergo in order to preserve the motor and brain function that retain at the present moment.
The application could be put into daily use in hospitals and doctors clinics around the country and even around the around the world in order to be able to quickly screen for dementia and other cognitive impairments.

### Programming language(s)

> List the proposed language(s) to be used.

C# / .Net for the base application. 
We would like to incorporate a mini database in either SQL/Firebase/MongoDB in order to store patient info such as past test scores and graphic info generated based on these results.

### Programming tools / Tech stack

> Describe the compiler, database, web server, etc., and any other software tools you plan to use.

We are hoping to use C# and .Net in order to develop the application. We then plan to use Selenium in order to run a suite of automated regression UI tests in order to make sure all aspects of the UI works and functions as intended.
We are also looking into integrating xaramin which is an abstraction layer between the C# code and the Android/iOS platforms. 
This would allow us to tackle the diverse nature of the application and be used on multiple platforms depending on resources available.

### Hardware

> Describe any non-standard hardware components which will be required.

We do not foresee needing any non standard hardware components. However if we do want to test our application on patients we will need attain ethical approval due to the delicate nature of dealing with patients of cognitive impairment and medical professionals. 
We will do our best to carry out any work with such patients and testers in the upmost professional manner in order to achieve the best results of our application.  

### Learning Challenges

> List the main new things (technologies, languages, tools, etc) that you will have to learn.

Both of us got an introduction to C#, .NET and Selenium while out on our INTRA placement but now we will have to use these skills to develop and application from start to finish.
This will be challenging as we were both used to working on pre-existing applications while on INTRA.
Another challenge will be getting our C# code to interact with Xaramin and the iOS and Android Platforms.

We will have to learn an effective method for incorporating a mini database into  the application for record storage and retrieval.
We will need to make sure all the data is stored properly and able to be viewed. 
Then the next thing will be to make sure retrieving the data is fast but still returns the right data.

Another challenge will be to use the results we gather for a certain patient to predict the rate of the progression of the impairment. 
We will need to be very accurate in the predication in order for the feature to be useful in diagnosis and treatment.

### Breakdown of work

> Clearly identify who will undertake which parts of the project.
>
> It must be clear from the explanation of this breakdown of work both that each student is responsible for
> separate, clearly-defined tasks, and that those responsibilities substantially cover all of the work required
> for the project.

We are planning on dividing the work load up evenly and not have one person do more than the other. 
Both of us will do any research into the topic together in order to both be working of the same knowledge base not have one person not knowing why things are being done in a certain way.
We will both have to do work on aspects of the UI and due to this we will have the other member write automated tests for the UI elements in order to find bugs and avoid bias of only testing parts we know will work.
We will also consistently document and present our work to the other partner in order to stay up to date with each others work and be able to bounce ideas off one another and hash out any queries we may have with how one part is done or is supposed to work.
This will allow us to get the project done in a timely manner and to a high standard.

#### Student 1

> *Student 1 should complete this section.*

#### Student 2

> *Student 2 should complete this section.*

## Example

> Example: Here's how you can include images in markdown documents...

<!-- Basically, just use HTML! -->

<p align="center">
  <img src="./res/cat.png" width="300px">
</p>

