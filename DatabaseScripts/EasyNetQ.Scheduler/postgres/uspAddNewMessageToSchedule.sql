CREATE OR REPLACE FUNCTION "uspAddNewMessageToScheduler"(p_waketime timestamp without time zone, p_bindingkey character varying, p_message bytea)
  RETURNS void AS
$BODY$DECLARE 
	v_newid integer;
BEGIN

insert into workItems (bindingKey, innerMessage) values (p_bindingkey, p_message);

v_newid = lastval();

insert into workItemStatus (workItemId, status, wakeTime) values (v_newid, 0, p_wakeTime);
	
END;$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION "uspAddNewMessageToScheduler"(timestamp without time zone, character varying, bytea)
  OWNER TO postgres;
