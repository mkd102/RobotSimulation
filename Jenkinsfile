pipeline{
  agent any
  
  
  stages{
    stage("build"){
       steps{
        echo 'building application'
        dotnet restore "RobotSimulation/RobotSimulation/RobotSimulation.csproj"

        dotnet build "RobotSimulation/RobotSimulation/" --configuration Release
        
      }
    }
   stage("test"){
     steps{
        echo 'testing application'
        
      }
    }
    stage("deploy"){
      steps{
        echo 'deploying application'
        
      }
    }
    
  }
  
  
}
