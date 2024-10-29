pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/Anirudh-WB/CiCd'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet restore'
                bat 'dotnet build --configuration Release'
            }
        }

        stage('Test') {
            steps {
                bat 'dotnet test'
            }
        }

        stage('Publish') {
            steps {
                bat 'dotnet publish --configuration Release --output ./publish'
            }
        }

        stage('Docker Build') {
            steps {
                bat 'docker build -t cicd:latest ./CiCd.API'
            }
        }

        stage('Docker Push') {
            steps {
                withCredentials([usernamePassword(credentialsId: 'dockerHubCredentials', passwordVariable: 'DOCKER_PASSWORD', usernameVariable: 'DOCKER_USERNAME')]) {
                    bat 'docker login -u %DOCKER_USERNAME% -p %DOCKER_PASSWORD%'
                    bat 'docker tag cicd:latest %DOCKER_USERNAME%/cicd:latest'
                    bat 'docker push %DOCKER_USERNAME%/cicd:latest'
                }
            }
        }

        stage('Docker Run') {
            steps {
                withCredentials([usernamePassword(credentialsId: 'dockerHubCredentials', passwordVariable: 'DOCKER_PASSWORD', usernameVariable: 'DOCKER_USERNAME')]) {
                    bat 'docker run -d -p 5000:8080 %DOCKER_USERNAME%/cicd:latest'
                }
            }
        }

        stage('Minikube Setup') {
            bat 'kubectl config use-context minikube'

            bat 'kubectl delete deployment weatherapi-deployment --ignore-not-found=true'
            bat 'kubectl delete service weatherapi-service --ignore-not-found=true'
        }

        stage('Kubernetes Deployment') {
            steps {
                bat 'kubectl apply -f deployment.yaml'
            }
        }

        stage('Kubernetes Services') {
            steps {
                bat 'kubectl apply -f service.yaml'
            }
        }
    }
}