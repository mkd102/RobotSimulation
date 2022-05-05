pipeline{
  agent any
  
  
  stages{
    stage("build"){
       steps{
        echo 'building application'
        dotnet build /RobotSimulation.sln
        
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
