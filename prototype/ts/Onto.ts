import { applySnapshot, getSnapshot, model, Model, prop } from 'mobx-keystone';


@model('onto')
class Onto extends Model({}) {

    public readonly isOnto = true;

    public get<T extends { name: string } = any>(klass: T): T[] {
        return Object.keys(this.$).map(name => {
            const member = (this as any)[name];

            if (Array.isArray(member)) {
                if (name === klass.name) {
                    return member;
                }
                else if (member.length > 0 && member[0].isOnto) {
                    return member.map(membee => membee.get(klass)).reduce(_concat, []);
                }
            }
            else {
                if (name === klass.name) {
                    return [member];
                }
                else if (member.isOnto) {
                    return member.get(klass);
                }
            }

            return undefined;
        })
        .filter(a => a !== undefined)
        .reduce(_concat, []);
    }

} 

export default Onto;


/**
 * Serialization
 */

export function serialize<T extends object>(obj: T) {
    function _serialize(tree: { $modelType: string }) {
        // Serialize
        delete tree.$modelType;

        _traverse(tree, _serialize);
        return tree;
    }

    const tree = getSnapshot<T>(obj) as { $modelType: string };
    const modelType = tree.$modelType.replace('onto/', '');
    return { [modelType]: _serialize(tree) };
}

export function deserialize<T extends object>(instance: T, json: any): T {
    function _deserialize(tree: any, key: string) {
        // Deserialize
        tree.$modelType = `onto/${key}`;         

        _traverse(tree, _deserialize);
    }

    _deserialize(json, Object.keys(json)[0]);
    applySnapshot(instance, json);
    return instance;
}


/**
 * Private utils
 */

function _concat(a: any[], b: any[]): any[] {
    return [...a, ...b];
}

function _traverse(tree, fn) {
    Object.entries(tree).forEach(([key, member]: any[]) => {
        if (typeof member !== 'number' && typeof member !== 'string') {
            if (Array.isArray(member)) {
                member.forEach(member => fn(member, key));
            }
            else {
                fn(member, key);
            }
        }
    });

}
