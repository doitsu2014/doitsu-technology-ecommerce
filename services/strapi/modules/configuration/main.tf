resource "kubernetes_namespace" "namespace" {
  metadata {
    name = var.namespace
  }
}

resource "kubernetes_secret" "secret-basic-authentication" {
  metadata {
    name = "basic-authentication"
    namespace = var.namespace 
  }

  data = {
    auth = "${file("${path.module}/basic-authentication-htpasswords/auth")}",
  }
}

output "k8s_secret_basic_authentication" {
  value = kubernetes_secret.secret-basic-authentication.metadata[0].name
}