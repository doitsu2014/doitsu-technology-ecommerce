resource "helm_release" "k8s-services-strapi" {
  name       = "strapi"
  repository = "https://dapr.github.io/helm-charts"
  chart      = "dapr"
  version    = "1.9"
  namespace  = var.namespace

  values = [
    "${file("${path.module}/values/dapr-values.yml")}"
  ]
}

resource "helm_release" "k8s-services-dapr-components" {
  name       = "dapr-components"
  chart      = "${path.module}/helm-charts/dapr-components"
  namespace  = var.namespace
}
