Version=$(git log --format="%h" -n 1)
Repository="microservices.notification"
FEEDER=$1
FEEDER_USERNAME=$2
FEEDER_PASSWORD=$3

echo $FEEDER $FEEDER_USERNAME $FEEDER_PASSWORD

docker build . -t $Repository --build-arg FEEDER=$FEEDER --build-arg FEEDER_USERNAME=$FEEDER_USERNAME --build-arg FEEDER_PASSWORD=$FEEDER_PASSWORD
docker image tag $Repository "$Repository:latest"
docker image tag $Repository "$Repository:$Version"