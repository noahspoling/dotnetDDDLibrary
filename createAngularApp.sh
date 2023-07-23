# Create the Angular application
ng new $projectname-app

cd $projectname-app

cd $projectname-app

# Interactive module/component/service/model generation

while true; do
    echo "Do you want to create a new module? (yes/no)"
    read answer
    if [ "$answer" == "yes" ]; then
        echo "Enter the module name:"
        read modulename
        ng generate module $modulename

        while true; do
            echo "Do you want to add a component to this module? (yes/no)"
            read answer
            if [ "$answer" == "yes" ]; then
                echo "Enter the component name:"
                read componentname
                ng generate component $modulename/$componentname
            else
                break
            fi
        done

        while true; do
            echo "Do you want to add a service to this module? (yes/no)"
            read answer
            if [ "$answer" == "yes" ]; then
                echo "Enter the service name:"
                read servicename
                ng generate service $modulename/$servicename
            else
                break
            fi
        done

        while true; do
            echo "Do you want to add a model to this module? (yes/no)"
            read answer
            if [ "$answer" == "yes" ]; then
                echo "Enter the model name:"
                read modelname
                ng generate class $modulename/models/$modelname
            else
                break
            fi
        done
    else
        break
    fi
done

echo "Project $projectname created successfully."