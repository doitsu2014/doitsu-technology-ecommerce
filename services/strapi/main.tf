terraform {
  required_providers {
    kubernetes = {
      source = "hashicorp/kubernetes"
      version = "2.22.0"
    }

    helm = {
      source = "hashicorp/helm"
      version = "2.10.1"
    }
  }
}

provider "kubernetes" {
  config_path = "./kubeconfigs/microk8s-kubeconfig.yml"
}

provider "helm" {
  kubernetes {
    config_path = "./kubeconfigs/microk8s-kubeconfig.yml"
  }
}

module "configuration" {
  source = "./modules/configuration"
}

module "strapi" {
  source = "./modules/strapi"

  depends_on = [
    module.configuration
  ]
}
