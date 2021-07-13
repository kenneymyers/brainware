# BrainWare

This is a simple project based upon the original BrainWare solution provided by Brainshark. This application is lean, but functional and has the following requirements.

# Requirements

This project must be build using .NET 5. It is a core project for easy portability and deployment to Windows or Linux servers. If you do not have .NET 5 please download it before attempting to run this solution.

# Core Concepts

This application now uses blazor and a service based approach to the problem. The data was heavily normalized and services are where all of the interaction with the database takes place using EF core and code first. You are welcome to use migrations to get everything going if you somehow remove the provided sqlite database.

# Additional Things I Would Do

I would paginate the results of the database query before displaying it to the user. I would also most likely provide a scope factory to control the context once more CRUD operations were added to the underlying services.

# Questions

If you have any questions or need assistance please don't hesitate to contact me. You can reach me via twitter @kenneymyers.
