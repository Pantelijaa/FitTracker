$modules = @(
    @{ Project = "src/Modules/Workouts/FitTracker.Workouts.Infrastructure"; Context = "WorkoutsContext" },
    @{ Project = "src/Modules/Stakeholders/FitTracker.Stakeholders.Infrastructure"; Context = "StakeholdersContext" },
    @{ Project = "src/Modules/Exercises/FitTracker.Exercises.Infrastructure"; Context = "ExercisesContext" },
    @{ Project = "src/Modules/Cooperation/FitTracker.Cooperation.Infrastructure"; Context = "CooperationContext" },
    @{ Project = "src/Modules/Chat/FitTracker.Chat.Infrastructure"; Context = "ChatContext" }
)

foreach ($module in $modules) {
    dotnet ef database update `
        --project $module.Project `
        --startup-project src/API/FitTracker.API `
        --context $module.Context
}