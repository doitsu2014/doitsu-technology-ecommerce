resource "helm_release" "k8s-services-strapi" {
  name       = "strapi"
  repository = "https://dapr.github.io/helm-charts"
  chart      = "strapi"
  version    = "10.0.10"
  namespace  = var.namespace

  values = [
    "${file("${path.module}/values/values.yml")}"
  ]
}



resource "kubernetes_ingress_v1" "ingress-cms" {
  metadata {
    name      = "ingress-cms"
    namespace = var.namespace
    annotations = {
      "kubernetes.io/ingress.class"             = "public"
      "nginx.ingress.kubernetes.io/auth-type"   = "basic"
      "nginx.ingress.kubernetes.io/auth-secret" = "basic-authentication"
      "nginx.ingress.kubernetes.io/auth-realm"  = "Authentication Required - administrator"
    }
  }

  spec {
    default_backend {
      service {
        name = "web"
        port {
          number = 1377
        }
      }
    }

    rule {
      host = "cms.doitsu.tech"
      http {
        path {
          path_type = "Prefix"
          path      = "/"
          backend {
            service {
              name = "web"
              port {
                number = 8084
              }
            }
          }

        }
      }
    }
  }
}
