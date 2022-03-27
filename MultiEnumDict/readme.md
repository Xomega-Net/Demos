# Demo for multi-enum dictionaries

The current solution provides a demo for modeling objects that store multiple enumerations using Xomega.

## Setup and requirements

The DB structure is set up using the [structure.sql](structure.sql).

The `BusinessObjectType` table stores enumeration items for multiple enumerations, as differentiated by the `BusinessObject` field, which comes from the `BusinessObject` table.

The `MaintenanceTemplate` table has fields `ScheduleType` and `WorkOrderType` that reference specific enumerations (business objects).

**Requirement:** The app should restrict enum items for those fields to the proper enumerations.

## Xomega steps and features

1. Create a Xomega solution for Blazor Server and WebAssembly.
1. Import the model from the DB.
1. Import the `business object` values from DB as a Xomega enum, to have generated constants for the values.
1. Create a custom "read enums" operation using "Enumeration Read List" generator. Change "business object" param to return the "enum type", which is a concatenation of the BO enum name and the ID to make it globally unique.
1. Build the model and implement this custom parameter in the `BusinessObjectTypeService`
1. Create data properties `ScheduleTypeProperty` and `WorkOrderTypeProperty` that extend the `EnumIntProperty` and set the appropriate enum type.
1. Add two logical types `work order type` and `schedule type` that extend `business object type` and map to the properties above. This will allow to easily configure multiple fields or params with those types in the Xomega model.
1. Change the types of the `schedule type` and `work order type` fields of the `maintenance template` object to use the appropriate logical types added above.
1. Generate CRUD with Views for the `maintenance template` object.

## Additional steps

For additional cleanup, set the the text for the group menu item in the `Startup` file of the Blazor.Server project and the `Program` file of the Blazor.Wasm project as follows.

```csharp
    MainMenu.Items[1].Text = "Maintenance";
```

Normally though, you'd want your objects to be defined in a module (which is imported from the DB from the SQL Server schema name), and the text of the generated group menu will be derived from the module name.