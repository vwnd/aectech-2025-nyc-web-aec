import { ChevronsUpDown } from "lucide-react";
import { useState } from "react";
import { Button } from "./ui/button";
import {
  Collapsible,
  CollapsibleContent,
  CollapsibleTrigger,
} from "./ui/collapsible";
import { Item, ItemContent, ItemTitle } from "./ui/item";
import {
  Table,
  TableBody,
  TableCaption,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "./ui/table";

interface PropertiesTableProps {
  id: string;
  properties: Record<string, string>;
}

export default function PropertiesTable({
  id,
  properties,
}: PropertiesTableProps) {
  const [isOpen, setIsOpen] = useState(false);
  const keys = Object.keys(properties);

  return (
    <Collapsible open={isOpen} onOpenChange={setIsOpen}>
      <Item variant="outline" size="sm">
        <ItemContent>
          <ItemTitle className="flex justify-between items-center w-full">
            <span>Element ID - {id}</span>
            <CollapsibleTrigger asChild>
              <Button variant="ghost" size="icon">
                <ChevronsUpDown />
              </Button>
            </CollapsibleTrigger>
          </ItemTitle>

          <CollapsibleContent>
            <Table>
              <TableCaption>{id}</TableCaption>
              <TableHeader>
                <TableRow>
                  <TableHead>Property</TableHead>
                  <TableHead>Value</TableHead>
                </TableRow>
              </TableHeader>
              <TableBody>
                {keys.map((key) => (
                  <TableRow key={key}>
                    <TableCell className="font-medium">{key}</TableCell>
                    <TableCell>{properties[key]}</TableCell>
                  </TableRow>
                ))}
              </TableBody>
            </Table>
          </CollapsibleContent>
        </ItemContent>
      </Item>
    </Collapsible>
  );
}
