pipeline{
  agent any
  
  
  stages{
      stage('Nuget Restore') {
      steps {
        bat label: 'Nuget Restore', 
        script: '''
          nuget restore "RobotSimulation\\RobotSimulation.sln"
          echo "Nuget Done Starting Msbuild *************"
        ''' 
      }
    }

    stage('build') {
      steps {
        script {
          //def msbuild = tool name: 'msbuild_2017', type: 'hudson.plugins.msbuild.MsBuildInstallation'
          tool name: 'msbuild_2017', type: 'msbuild'
          bat "\"${tool 'msbuild_2017'}\"\\msbuild.exe RobotSimulation\\RobotSimulation.sln \""
        }
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
