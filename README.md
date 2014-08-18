WPFDataForms
=============

A library of form field controls and associated ViewModels that attempt to ease form generation, encapsulation, and validation in WPF applications.

Summary
-------

This library is meant to help developers generate data input and display forms in WPF applications. It also seeks to make form validation easy (hence the constructor for passing a user-defined validation method in each field object). Form fields are provided for various data types, styles, and contexts. Its components were part of the first simulation I wrote for UNLV Physics some years ago and "evolved" with each new piece of software I created that required form-data entry. Eventually its components were isolated, generalized, and thoroughly tested to include internal type-casting and iput validation for various data contexts, incuding visual notifications (colored border in this iteration) displayed at the developer's option. The goal is to implement data input and display fields for an amalgam of use-cases and make each of these fully testable in their respective contexts. (i.e. specialized form input/output for science, engineering, medicine, real-estate, commerce, etc) 

This (like many others) library is based almost entirely around the notion that a developer can focus on making awesome software when another (hopefully not boring) developer worries about the details for them. It only has a few methods for now, but will grow with the needs of my personal and university projects. It's also guaranteed to grow if Microsoft doesn't screw up their strategies for emerging versions of Windows - but that's another conversation altogether.

Notes
-----

All code in this library has been composed in a self-documenting fashion and styled for readability where possible. All public members, methods, and constructors have complete XML documentation for use with VS Intellisense.

This solution, including unit tests and architectural models, was created, debugged, and deployed using [Visual Studio 2012 Ultimate with MSDN](http://en.wikipedia.org/wiki/Microsoft_Visual_Studio#Visual_Studio_2012) (link contains addtional references). The solution may not open properly if you try using an earlier or less feature-saturated version of Visual Studio. If a later version is used, be sure to check the cloned solution against original source code to ensure that compatiblity changes haven't significantly altered existing functionality.

Instructions
------------

To get your machine ready for development with this repository:

1. Clone the repository to your machine.
2. Navigate to the directory you cloned your repository to.
3. Locate the Visual Studio 2012 solution file.
3. Open the solution in Visual Studio (2012 or later)

Viola! You're good to go!
