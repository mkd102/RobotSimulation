pipeline{
  agent any
  
  
  stages{
    stage("build"){
       steps{
        echo 'building application'
        dotnet build
        
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
